import React from 'react';

const user = {
    userCredentials: {
      Username: "luka28798",
      Password: "123abc"
    },
    userAdverts: {
      adverts: ["Prodajem Galaxy S8", "Prodajem auto...", "Prodajem kosilicu"]
    }
  }
  const advert = {
    advertInfo: {
      advertCategory: "Mobiteli",
      advertTitle: "Prodajem Galaxy S8"
    }
    
    
  }

function App(){
    return (
        <div className = "App">
            <p>Podaci o oglasu:</p>
            <p>Naslov: {advert.advertInfo.advertTitle}</p>
            <p>Kategorija: {advert.advertInfo.advertCategory} </p>
            <p>Podaci o korisniku:</p>
            <p>Username: {user.userCredentials.Username}</p>
            <p>Oglasi:</p>
            <div style={{'whiteSpace':'pre-line'}}>
                {user.userAdverts.adverts.join('\n')}
            </div>
        </div>
    );
}

export default App;