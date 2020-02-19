import React, { useState, useEffect } from 'react';
import { StyleSheet, View, ScrollView, Text } from 'react-native';
import Checkpoint from '../components/Checkpoint';
import UserHeader from '../components/UserHeader';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import Api from '../Services/Api';

export default function RoadMap({ navigation }) {

  navigation.setOptions({ headerTitle: 'Aprenda' });

  const [checkPoints, setcheckPoints] = useState([]);

  const [user, setUser] = useState({});

  useEffect(() => {
    const unsubscribe = navigation.addListener('focus', () => {
      async function setUserAsync() {
        var user = await GetUserSettings();
        setUser(user);
      };
      setUserAsync();
    });
    return unsubscribe;
  }, [navigation]);

  useEffect(() => {

    async function getTrails() {
      await Api.get(`/trails`)
        .then(function (response) {
          setcheckPoints(JSON.parse(response.request._response))
        }.bind(this))
        .catch(function (error) {
          console.log(error);
        }.bind(this))
        .finally(function () {
          console.log('chamou');
        }.bind(this));
    };

    getTrails();
  }, []);

  async function handleOnCheckpointClick(trailID, type) {

    var path = '';

    switch (type) {
      case 'video' || 'Video':
        path = 'Video';
        break;
      case 'quiz' || 'Quiz':
        path = 'Quiz';
        break;
      case 'text' || 'Text':
        path = 'Text';
        break;
      default:
        return;
    }
    navigation.navigate('Checkpoint' + path, { trailID: trailID })
  }

  return (
    <View style={styles.container}>

      <UserHeader coins={user.coins} trailID={user.trailID} />
      <ScrollView
        style={[styles.scrollView, { Height: "auto" }]}
        contentContainerStylgetParame={styles.scrollViewContainer}
      >
        {
          checkPoints.map(rm =>
            (
              <Checkpoint key={rm.id} _roadmap={rm} user={user} locked={rm.id > user.trailID} onClick={handleOnCheckpointClick} />
            )
          )
        }
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
})

RoadMap.navigationOptions = {
  header: null,
};
