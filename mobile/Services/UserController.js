import * as SecureStore from 'expo-secure-store';

async function SetUserSettings(_user){
    var user = _user;
    if(_user == undefined)
    {
        user = {
            email: "leonardo.bonetti.silva@gmail.com",
            password: "L1v2f3s4@",
            trailID: 1,
            coins: 1000
          };
    }else
    {
        user = _user;
    }
    
    await SecureStore.setItemAsync('user', JSON.stringify(user));
}

async function GetUserSettings()
{
    var user = await SecureStore.getItemAsync('user');
    var userObj = JSON.parse(user);
    return userObj;
}
  
export {
    SetUserSettings,
    GetUserSettings
}