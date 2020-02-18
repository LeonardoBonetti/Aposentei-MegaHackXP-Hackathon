import React, { useState, useEffect } from 'react';
import { StyleSheet, View , Text, Image } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

export default function Product(props) {

  const { product } = props;

  function BuyButton(){
    var enabled = props.enabled;
    return (
      <TouchableOpacity activeOpacity={0.5} onPress={(e) => { props.onClick(e, product)}}>
        <View style={[enabled ? styles.buttonEnabled: styles.buttonDisabled,styles.button]}>
          <Text style={styles.buttonLabel}>Trocar por {product.price}  
            <Image style={styles.buttonImage} source={require('../assets/icons/moeda.png')}/>
          </Text>
        </View>
      </TouchableOpacity> 
    )
  } 

  return (
      <View style={styles.product}>
         <View style={styles.row}>
            <View style={styles.column}>
              <Image style={styles.icon} source={{uri: product.image_url}}></Image>
            </View>

            <View style={styles.column}>
              <Text style={styles.title}>{product.title}</Text>
              <Text style={styles.description}>{product.description}</Text>
              <BuyButton />
            </View>
         </View>
      </View>


  );
}
const styles = StyleSheet.create({
  product:{
    width: 350,
    height: 200,
    marginTop:20,
    borderRadius: 10,
    borderWidth: 2,
    borderColor: '#ffba03',
    opacity: 0.9,
  },
  row:{
    padding: 20,
    width:'100%',
    flexDirection: 'row',
  },
  column:{
    width:'50%',
    justifyContent: 'center'
  },
  icon:{
    width: 100,
    height: 100
  },
  title:{
    fontSize: 15,
    fontWeight: "bold",
    marginBottom: 5
  },
  description:{
    marginLeft: 5,
    fontSize: 14
  },
  button:{
    alignItems: 'center',
    padding: 5,
    marginTop: 5,
    borderRadius: 3
  },
  buttonEnabled: {
    backgroundColor: '#4d0250',
  },
  buttonDisabled:{
    backgroundColor: '#8f8f8f',
  },
  buttonLabel:{
    color:'white',
  },
  buttonImage:{
    width: 15, 
    height: 15
  }
});
