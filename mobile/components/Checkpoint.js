import React, { useState, useEffect } from 'react';
import { StyleSheet, View, Text, Image } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';
import Icon from '../components/Icon';
export default function Checkpoint(props) {

  const { _roadmap } = props;
  function IsLocked(props) {
    if (props.locked) {
      return (
        <View style={styles.locked}><Icon size={20} name="md-lock" /></View>
      )
    }
    else {
      return (
        <View></View>
      )
    }

  }

  return (
    <TouchableOpacity disabled={props.locked} activeOpacity={0.5} onPress={(e) => { props.onClick(_roadmap.id, _roadmap.typeDescription) }}>
      <View style={styles.checkpoint}>
        <Text style={styles.title}>{_roadmap.title}</Text>
        <Text style={styles.description}>{_roadmap.description}</Text>
        <Image style={styles.userHeaderIcon} source={require('../assets/icons/nivel.png')} />
        <IsLocked locked={props.locked} />
      </View>
    </TouchableOpacity>
  );
}
const styles = StyleSheet.create({
  checkpoint: {
    alignItems: 'center',
    width: 350,
    height: 150,
    backgroundColor: '#4d0250',
    marginTop: 10,
    borderRadius: 10,
    padding: 10,
    paddingTop: 40,
    borderWidth: 0.5,
    borderColor: '#2f0030',
    opacity: 0.9
  },
  title: {
    color: 'white',
    fontSize: 18,
    textAlign: 'center',
    marginBottom: 5
  },
  description: {
    color: 'white',
    fontSize: 12,
    textAlign: 'center'
  },
  locked: {
    position: 'absolute',
    top: 5,
    right: 5,
  },
  userHeaderIcon: {
    width: 23,
    height: 23,
    position: 'absolute',
    top: 5,
    left: 5,
  }
});

