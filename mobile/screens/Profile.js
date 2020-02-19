import * as React from 'react';
import { Image, Platform, StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import * as WebBrowser from 'expo-web-browser';

import { MonoText } from '../components/StyledText';

export default function Profile() {

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
        <Text style={{ fontSize: 25, marginTop: 50 }}>Em desenvolvimento</Text>
      </ScrollView>
    </View>
  );
}

Profile.navigationOptions = {
  header: null,
};


const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    backgroundColor: '#f6f7eb'
  },
  scrollView: {
    backgroundColor: '#f6f7eb'
  },
});
