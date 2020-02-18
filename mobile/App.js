import * as React from 'react';
import { Platform, StatusBar, StyleSheet, View } from 'react-native';
import { SplashScreen } from 'expo';
import * as Font from 'expo-font';
import { Ionicons } from '@expo/vector-icons';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import BottomTabNavigator from './navigation/BottomTabNavigator';
import useLinking from './navigation/useLinking';
import { SetUserSettings, GetUserSettings } from './Services/UserController';
import CheckpointQuiz from './screens/CheckpointQuiz';
import CheckpointText from './screens/CheckpointText';
import CheckpointVideo from './screens/CheckpointVideo';
import RoadMap from './screens/RoadMap';

const Stack = createStackNavigator();

export default function App(props) {
  const [isLoadingComplete, setLoadingComplete] = React.useState(false);
  const [initialNavigationState, setInitialNavigationState] = React.useState();
  const containerRef = React.useRef();
  const { getInitialState } = useLinking(containerRef);

  // Load any resources or data that we need prior to rendering the app
  React.useEffect(() => {
    async function loadResourcesAndDataAsync() {
      try {
        SplashScreen.preventAutoHide();

        // Load our initial navigation state
        setInitialNavigationState(await getInitialState());

        // Load fonts
        await Font.loadAsync({
          ...Ionicons.font,
          'space-mono': require('./assets/fonts/SpaceMono-Regular.ttf'),
        });
      } catch (e) {
        // We might want to provide this error information to an error reporting service
        console.warn(e);
      } finally {
        setLoadingComplete(true);
        SplashScreen.hide();
      }
    }
    SetUserSettings();
    loadResourcesAndDataAsync();
  }, []);

  var screenOptions = {
    headerStyle: {
      backgroundColor: '#4d0250',
      borderBottomColor: '#ffba03',
      borderBottomWidth: 3
    },
    headerTitleStyle: {
      color: '#ffba03'
    }
  };

  if (!isLoadingComplete && !props.skipLoadingScreen) {
    return null;
  } else {
    return (
      <View style={styles.container}>
        {Platform.OS === 'ios' && <StatusBar barStyle="default" />}
        <NavigationContainer ref={containerRef} initialState={initialNavigationState}>
          <Stack.Navigator>
            <Stack.Screen options={screenOptions} name="Root" component={BottomTabNavigator} />


            <Stack.Screen options={screenOptions} name="CheckpointQuiz" component={CheckpointQuiz} />
            <Stack.Screen options={screenOptions} name="CheckpointText" component={CheckpointText} />
            <Stack.Screen options={screenOptions} name="CheckpointVideo" component={CheckpointVideo} />
            {/* <Stack.Screen options={screenOptions} name="RoadMap" component={RoadMap} /> */}

          </Stack.Navigator>
        </NavigationContainer>
      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
