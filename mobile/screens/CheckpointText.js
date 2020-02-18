import React, { useState, useEffect, } from 'react';
import { StyleSheet, Text, TouchableOpacity, View, ScrollView } from 'react-native';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import { simpleAlertCallback } from '../utils/Alerts';
import DefaultButton from '../components/DefaultButton';

export default function CheckpointText({ route, navigation }) {
  navigation.setOptions({ headerTitle: 'Leitura' });

  const [textState, setTextState] = useState({paragraphs:[]}); //waiting / result
  const [user, setUser] = useState({});

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
      var paragraphs = 'A liberdade financeira, nada mais é que a liberdade que um indivíduo alcança no campo das finanças. Atingido o patamar da liberdade financeira, é possível tomar decisões financeiras com maior tranqüilidade – como optar ou não, por exemplo, por realizar um trabalho.;Quando uma pessoa atinge a sua liberdade financeira as preocupações excessivas com o dinheiro acabam diminuindo, pois o foco principal poderá ser direcionado para a construção da vida financeira e acumulação de patrimônio – permitindo que esta pessoa faça escolha financeiras com maior tranqüilidade.;Apesar disso, é importante ter em mente que, conceitualmente, é possível que uma pessoa tenha sua liberdade financeira sem, necessariamente, ter alcançado a  independência financeira. Mesmo porque existem pessoas que simplesmente não desejam alcançar a independência financeira, apenas procuram alcançar a liberdade no campo das finanças.'
      
      var text = {
        trailID: trailID,
        title: 'Liberdade financeira !',
        reward: 101,
        paragraphs: paragraphs.split(';')
      };
      setTextState(text);
    };

    getQuizData();
  }, []);

  async function handleCompleteTrail()
  {  
    var _user = user;
    user.coins += textState.reward;
    user.trailID += 1;
    setUser(_user);
    await SetUserSettings(_user);

    //Update no banco
    simpleAlertCallback('Muito bom', 'Parabéns, você adquiriu mais conhecimento rumo a sua independência financeira', () => {navigation.push('RoadMap')});
  }

  return (
    <View style={styles.container}>
      <ScrollView
        style={[styles.scrollView, { Height: "auto" }]}
        contentContainerStyle={styles.scrollViewContainer}
      >    
        <View style={styles.textContent}>   
          <Text style={styles.title}>{textState.title}</Text>
          {
              textState.paragraphs.map(p => (
                <Text style={styles.paragraph}>{p}</Text>
              ))
          }
        </View>
        <DefaultButton enabled={user.trailID <= textState.trailID} onClick={handleCompleteTrail} text={"Marcar como lido"}/>
      </ScrollView>
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
  textContent: {
    padding: 10
  },
  title: {
    fontSize: 22,
    marginBottom: 20,
  },
  paragraph: {
    textAlign: 'justify',
    marginBottom: 10,
    fontSize: 16
  }
})

CheckpointText.navigationOptions = {
  header: null,
};
