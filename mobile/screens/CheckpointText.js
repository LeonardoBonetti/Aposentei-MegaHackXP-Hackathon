import React, { useState, useEffect, } from 'react';
import { StyleSheet, Text, TouchableOpacity, View, ScrollView, Image } from 'react-native';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import { simpleAlertCallback } from '../utils/Alerts';
import DefaultButton from '../components/DefaultButton';
import Api from '../Services/Api';

export default function CheckpointText({ route, navigation }) {
  navigation.setOptions({ headerTitle: 'Leitura' });

  const [textState, setTextState] = useState({ paragraphs: [] }); //waiting / result
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

      await Api.get(`/textTrail/${trailID}`)
        .then(function (response) {
          var _resp = JSON.parse(response.request._response);
          var paragraphs = _resp.paragraphs;
          _resp.paragraphs = paragraphs.split(';');
          setTextState(_resp);
        }.bind(this))
        .catch(function (error) {
          console.log(error);
        }.bind(this))
        .finally(function () {
        }.bind(this));
    };

    getQuizData();
  }, []);

  async function handleCompleteTrail() {
    var _user = user;
    user.coins += textState.reward;
    user.trailID += 1;
    setUser(_user);
    await SetUserSettings(_user);

    //Update no banco
    simpleAlertCallback('Muito bom', 'Parabéns, você adquiriu mais conhecimento rumo a sua independência financeira', () => { navigation.navigate('Root') });
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
          <Text style={styles.productsHeader}>Melhores investimentos</Text>
          <Image style={styles.products} source={require('../assets/images/produtos.png')} />

        </View>
        <DefaultButton enabled={user.trailID <= textState.id} onClick={handleCompleteTrail} text={"Marcar como lido"} />
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
  },
  productsHeader: {
    textAlign: 'justify',
    marginBottom: 10,
    marginTop: 10,
    fontSize: 20,
    fontWeight: 'bold'
  },
  products: {
    resizeMode: 'cover',
    width: '90%',
    height: 270,
    alignSelf: 'center'
  }
})

CheckpointText.navigationOptions = {
  header: null,
};
