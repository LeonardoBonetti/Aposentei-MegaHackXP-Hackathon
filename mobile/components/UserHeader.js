import React, { useState, useEffect } from 'react';
import { StyleSheet, View , Text, Image} from 'react-native';
import { GetUserSettings } from '../Services/UserController';

export default function UserHeader(props) {

  return (
    <View style={styles.userHeaderContent}>
      <Text style={styles.userHeaderText}>{props.trailID}
        <Image style={styles.userHeaderIcon} source={require('../assets/icons/nivel.png')}/>
      </Text>
      <Text style={styles.userHeaderText}>{props.coins}
        <Image style={styles.userHeaderIcon} source={require('../assets/icons/moeda.png')}/>
      </Text>
    </View>
  );
}
const styles = StyleSheet.create({
  userHeaderContent: {
    backgroundColor: '#dedede',
    width: '100%',
    flexDirection: 'row',
    borderBottomWidth: 1.5,
    borderColor: '#b5b5b5',
    flexDirection: 'row-reverse'
  },
  userHeaderText : {
    color: '#000',
    padding:10,
    textAlign: 'right',
    alignSelf: 'stretch',
    fontSize: 18,
  },
  userHeaderIcon:{
    width: 27, 
    height: 27,
    paddingLeft: 5
  }
});

