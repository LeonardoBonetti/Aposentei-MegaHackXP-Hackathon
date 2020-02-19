import React, { useState, useEffect, } from 'react';
import { StyleSheet, View, ScrollView } from 'react-native';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import { simpleAlert, simpleAlertCallback } from '../utils/Alerts';
import QuizComponent from '../components/QuizComponent';
import DefaultButton from '../components/DefaultButton';
import Api from '../Services/Api';

export default function CheckpointQuiz({ route, navigation }) {

  navigation.setOptions({ headerTitle: 'Teste seus conhecimentos' });


  const [quizState, setQUizState] = useState('waiting'); //waiting / result
  const [quiz, setQuiz] = useState({ questions: [] });
  const [quizAnswers, setQuizAnswers] = useState([]);
  const [user, setUser] = useState({});

  getChecked = (answer) => {
    var _answer = {
      questionID: parseInt(answer.split(';')[0]),
      answerID: parseInt(answer.split(';')[1]),
      correclty: answer.split(';')[2] == "true"
    };
    setQuizAnswers([...quizAnswers.filter(q => q.questionID !== _answer.questionID), _answer]);

  }

  useEffect(() => {
    async function setUserAsync() {
      var user = await GetUserSettings();
      setUser(user);
    };
    setUserAsync();
  }, []);

  useEffect(() => {
    async function getQuizData() {
      var { trailID } = route.params;
      await Api.get(`/quizTrail/${trailID}`)
        .then(function (response) {
          var _resp = JSON.parse(response.request._response);
          setQuiz(_resp);
        }.bind(this))
        .catch(function (error) {
          console.log(error);
        }.bind(this))
        .finally(function () {
        }.bind(this));
    };
    getQuizData();
  }, []);


  async function handleSendQuiz(e) {

    if (quizAnswers.length < quiz.questions.length) {
      simpleAlert('Ainda restam perguntas...', 'Responda todas as perguntas antes de continuar.');
    }
    else {
      var correcltyAnswers = quizAnswers.filter(q => q.correclty == true).length;

      if (correcltyAnswers >= Math.ceil(quizAnswers.length * 0.7)) {
        var _user = user;
        user.coins += quiz.reward + (correcltyAnswers * 10);
        user.trailID += 1;
        setUser(_user);
        await SetUserSettings(_user);

        simpleAlertCallback('Muito bom', `Você acertou ${correcltyAnswers} perguntas e passou para a próxima etapa !`, () => { navigation.navigate('Root') });
      }
      else {
        simpleAlertCallback('Faltou só um pouco :/', 'Você precisa acertar pelo menos 70% das perguntas, estude mais um pouco e tente novamente', () => { navigation.navigate('Root') });
      }


    }
  }

  function setscrollView(scroll) {
    // scroll.
  };

  return (
    <View style={styles.container}>
      <ScrollView
        ref={(scroll) => { setscrollView(scroll) }}
        style={[styles.scrollView, { Height: "auto" }]}
        contentContainerStyle={styles.scrollViewContainer}
      >
        {
          quiz.questions.map(q => (
            <QuizComponent question={q} getChecked={getChecked} />
          ))
        }
      </ScrollView>
      {/* <TouchableOpacity activeOpacity={0.5} onPress={handleSendQuiz}>
        <View style={styles.button}>
          <Text style={styles.buttonText}>Enviar</Text>
        </View>
      </TouchableOpacity> */}

      <DefaultButton enabled={user.trailID <= quiz.id} onClick={handleSendQuiz} text={"Enviar"} />

    </View>
  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    backgroundColor: '#f6f7eb'
  },
  scrollView: {
    backgroundColor: '#f6f7eb'
  },
  question: {
    marginBottom: 10,
    padding: 10,
    backgroundColor: '#fff'
  },
  questionTitle: {
    fontSize: 18
  },
  button: {
    alignItems: 'center',
    padding: 5,
    marginTop: 10,
    backgroundColor: '#4d0250',
    width: 100,
    marginBottom: 10,
    borderRadius: 3
  },
  buttonText: {
    color: 'white'
  }
})

CheckpointQuiz.navigationOptions = {
  header: null,
};
