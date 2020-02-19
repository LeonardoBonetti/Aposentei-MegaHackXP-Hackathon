import * as SecureStore from 'expo-secure-store';
import Api from '../Services/Api';

async function SetUserSettings(_user) {
    var user = _user;
    if (_user == undefined) {
        await Api.get(`/user`)
            .then(function (response) {
                user = JSON.parse(response.request._response);
            }.bind(this))
            .catch(function (error) {
                console.log(error);
            }.bind(this))
            .finally(function () {
            }.bind(this));
    } else {
        user = _user;
    }
    console.log(user);

    await SecureStore.setItemAsync('user', JSON.stringify(user));
}

async function GetUserSettings() {
    var user = await SecureStore.getItemAsync('user');
    var userObj = JSON.parse(user);
    return userObj;
}

export {
    SetUserSettings,
    GetUserSettings
}