import React, { useState, useEffect } from 'react';
import {StyleSheet, View, ScrollView,Text} from 'react-native';
import Checkpoint from '../components/Checkpoint';
import UserHeader from '../components/UserHeader';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';

export default function RoadMap({ navigation }) {

  const [checkPoints, setcheckPoints] = useState([
    {
      id: 1,
      title: 'Rumo a Dependência financeira !',
      description: 'Bem vindo, conheço nosso propósito.',
      trailTypeDto : {
        description: 'text',
        id: 1
      }
    },
    {
      id: 2,
      title: 'Como conquistar a independência financeira ',
      description: 'Ter um patrimônio que gere rendimentos suficientes para cobrir todos os seus gastos.',
      trailTypeDto : {
        description: 'video',
        id: 2
      }
    },
    {
      id: 3,
      title: 'Pratique',
      description: 'Teste os seus conhecimentos !',
      trailTypeDto : {
        description: 'quiz',
        id: 3
      }
    },
  ]);

  const [user, setUser] = useState({});

    useEffect(() => {
      async function setUserAsync() {
        var user = await GetUserSettings();
        setUser(user);
      };
      setUserAsync();
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
    navigation.push('Checkpoint'+path, { trailID: trailID })
  }

  function setscrollView(scroll) {
    // scroll.
  };
  
  return (
    <View style={styles.container}>
      
     <UserHeader coins={user.coins} trailID={user.trailID}/>
      <ScrollView
        ref={(scroll) => { setscrollView(scroll) }}
        style={[styles.scrollView, { Height: "auto"}]}
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
