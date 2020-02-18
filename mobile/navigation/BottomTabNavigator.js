import * as React from 'react';
import {Image} from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import RoadMap from '../screens/RoadMap';
import Store from '../screens/Store';
import Profile from '../screens/Profile';

const BottomTab = createBottomTabNavigator();
const INITIAL_ROUTE_NAME = 'RoadMap';

export default function BottomTabNavigator({ navigation, route }) {
  
  navigation.setOptions({ headerTitle: getHeaderTitle(route) });

  return (
    <BottomTab.Navigator initialRouteName={INITIAL_ROUTE_NAME}>
      <BottomTab.Screen
        name="RoadMap"
        component={RoadMap}
        options={{
          title: 'Aprenda',
          tabBarIcon: ({ focused }) => <Image style={{width: 30, height: 30}} source={require('../assets/icons/aprender.png')}/> ,
        }}
      />
       <BottomTab.Screen
        name="Store"
        component={Store}
        options={{
          title: 'Loja',
          tabBarIcon: ({ focused }) => <Image style={{width: 30, height: 30}} source={require('../assets/icons/loja.png')}/>,
        }}
      />
      <BottomTab.Screen
        name="Profile"
        component={Profile}
        options={{
          title: 'Perfil',
          tabBarIcon: ({ focused }) => <Image style={{width: 30, height: 30}} source={require('../assets/icons/perfil.png')}/>,
        }}
      />
    </BottomTab.Navigator>
  );
}

function getHeaderTitle(route) {
  const routeName = route.state?.routes[route.state.index]?.name ?? INITIAL_ROUTE_NAME;
  switch (routeName) {
    case 'RoadMap':
      return 'Aprenda e evolua';
    case 'Store':
      return 'Troque suas moedas';
    case 'Profile':
      return 'Visualize seu perfil';
    
  }
}
