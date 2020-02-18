import React, { useState, useEffect, } from 'react';
import { StyleSheet, Text, TouchableOpacity, View, ScrollView } from 'react-native';
import { WebView } from 'react-native-webview';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import { simpleAlertCallback } from '../utils/Alerts';
import DefaultButton from '../components/DefaultButton';


export default function CheckpointVideo({ route, navigation }) {

  navigation.setOptions({ headerTitle: 'Video' });

  const [videoState, setvideoState] = useState({ paragraphs: [] });
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

      var video = {
        trailID: trailID,
        title: 'Investindo em coelhos asassinos !',
        reward: 10,
        paragraphs: paragraphs.split(';'),
        url: 'https://storage.googleapis.com/hackaton-xp/y2mate.com%20-%20jhsf3_jhsf_participaoes_a_empresa_mais_luxuosa_da_bolsa_empresas_da_bolsa_6_pLsN2wK8ZSY_360p.mp4'
      };
      setvideoState(video);
    };

    getQuizData();
  }, []);

  function setscrollView(scroll) {
    // scroll.
  };

  async function handleCompleteTrail() {
    var _user = user;
    user.coins += videoState.reward;
    user.trailID += 1;
    setUser(_user);
    await SetUserSettings(_user);

    simpleAlertCallback('Muito bom', 'Parabéns, você adquiriu mais conhecimento rumo a sua independência financeira', () => { navigation.navigate('Root') });
  }


  return (
    <View style={styles.container}>
      <ScrollView
        ref={(scroll) => { setscrollView(scroll) }}
        style={[styles.scrollView, { Height: "auto" }]}
        contentContainerStyle={styles.scrollViewContainer}
      >
        <WebView
          style={styles.videoPlayer}
          javaScriptEnabled={true}
          source={{ uri: videoState.url }}
        />
        <View style={styles.textContent}>
          <Text style={styles.title}>{videoState.title}</Text>
          {
            videoState.paragraphs.map(p => (
              <Text style={styles.paragraph}>{p}</Text>
            ))
          }
        </View>
        <DefaultButton enabled={user.trailID <= videoState.trailID} onClick={handleCompleteTrail} text={"Marcar como visto"} />
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
  videoPlayer: {
    marginTop: 10,
    height: 230,
    // width: 370
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
  },
  button: {
    alignItems: 'center',
    padding: 15,
    marginTop: 10,
    backgroundColor: '#4d0250',

    marginBottom: 10,
    borderRadius: 3
  },
  buttonText: {
    color: 'white'
  },
})

CheckpointVideo.navigationOptions = {
  header: null,
};
