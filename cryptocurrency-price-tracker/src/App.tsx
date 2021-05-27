import React, {useState, useEffect} from 'react';
import axios from 'axios';

import './App.css';

// https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false

function App() {

  const [coins, setCoins] = useState([]);

  useEffect(() => {
    axios.get('https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false')
    .then(res => {
      setCoins(res.data);
      // console.log(res.data);
    }).catch(error => {
      alert(error)})
  }, []);

  return (
    <>
      <form>
          <input type="text" placeholder="Search" className="coin-input"/>
      </form>

      {/* Map all coins here */}
    </>
  );
}

export default App;
