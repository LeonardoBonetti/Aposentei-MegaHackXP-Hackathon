
import { Alert } from 'react-native';

function confirmAlert(title, message, okCallback) {
  Alert.alert(
    title,
    message,
    [
      {
        text: 'Não',
        style: 'cancel',
      },
      { text: 'Sim', onPress: okCallback },
    ],
    { cancelable: false }
  );
}

function simpleAlert(title, message) {
  Alert.alert(
    title,
    message,
    [
      { text: 'OK' },
    ],
    { cancelable: false }
  );
}

function simpleAlertCallback(title, message, callback) {
  Alert.alert(
    title,
    message,
    [
      { text: 'OK', onPress: callback  },
    ],
    { cancelable: false }
  );
}


export {
  confirmAlert,
  simpleAlert,
  simpleAlertCallback
}