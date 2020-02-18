import React, { useState, useEffect, } from 'react';
import { StyleSheet, View } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import Product from '../components/Product';
import { GetUserSettings } from '../Services/UserController';
import { confirmAlert, simpleAlert } from '../utils/Alerts';
 
export default function Store() {

  const [products, setProducts] = useState([
    {
      id: 1,
      url: 'https://www.amazon.com.br/Investidor-Inteligente-Benjamin-Graham/dp/8595080801/ref=sr_1_1?__mk_pt_BR=%C3%85M%C3%85%C5%BD%C3%95%C3%91&crid=3RTA54DZKH2RZ&keywords=o+investidor+inteligente&qid=1581886908&sprefix=o+investidor%2Caps%2C280&sr=8-1',
      title: 'Livro, O investidor Inteligente',
      image_url: 'https://opiniaobomvaleapena.com.br/imagens/livro-o-investidor-inteligente-o-guia-cl%C3%A1ssico-para-ganhar-dinheiro-na-bolsa.png',
      price: 400,
      description: 'Livro escrito por Benjamin Graham que vai mudar a forma que você investe',
      type: 'Livro'

    },
    {
      id: 2,
      url: 'https://www.hotmart.com/product/como-economizar-metade-do-seu-salario/M12185532I?sck=HOTMART_SITE',
      title: 'Curso, Como Economizar Metade do Seu Salário',
      image_url: 'https://static-media.hotmart.com/HojPdcDVy7LtRiWuEI80U10xSE8=/600x600/smart/filters:format(jpg):background_color(white)/hotmart/product_pictures/f1b0c5a0-9b31-4614-add6-edfed49e6288/Capturar.PNG',
      price: 200,
      description: 'Aprenda a economizar seu salário com esse excelente curso',
      type: 'Curso'

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
  
  function setscrollView(scroll) {
    // scroll.
  };

  function handleBuyButton(e, item) {

    if(user.coins >= item.price)
    {
      confirmAlert('Confirme a troca', `Tem certeza que deseja obter o ${item.type}`, () => handleConfirmButton(item))
    }
    else
    {
      simpleAlert('Ops','Você não possui moedas suficiente, ganhe moedas na aba "Aprenda"')
    }
  }

  function handleConfirmButton(item)
  {      
    //TODO Debitar
    simpleAlert('Já é seu !', 'Parabéns, você deu mais um passo rumo a sua liberdade financeira !')
  }

  return (
    <View style={styles.container}>
    <ScrollView
      ref={(scroll) => { setscrollView(scroll) }}
      style={[styles.scrollView, { Height: "auto"}]}
      contentContainerStyle={styles.scrollViewContainer}
    >          
      {
          products.map(p =>
            (
              <Product key={p.id} product={p} enabled={p.price <= user.coins} onClick={handleBuyButton} />
            )
          )
        }
    </ScrollView>
  </View>
  );
}

Store.navigationOptions = {
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
