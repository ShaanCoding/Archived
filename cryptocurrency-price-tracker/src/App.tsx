import React, {useState, useEffect} from 'react';
import axios from 'axios';

import './App.css';
import Coin from './Components/Coin';

// https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false

function App() {

  const [coins, setCoins] = useState([]);
  const [search, setSearch] = useState("");


  useEffect(() => {
    axios.get('https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false')
    .then(res => {
      setCoins(res.data);
      // console.log(res.data);
    }).catch(error => {
      alert(error)})
  }, []);

  const handleChange = (e: any) => {
    setSearch(e.target.value)
  };

  // Filter coin

  const filteredCoins = coins.filter((coin: any) => 
    coin.name.toLowerCase().includes(search.toLowerCase())   
  );

  return (
    <>
      <form>
          <input type="text" placeholder="Search" className="coin-input" onChange={handleChange}/>
      </form>

      {/* Map all coins here */}
      {filteredCoins.map((coin: any) => {
        return (
          <Coin key={coin.id} coinName={coin.name} coinImage={coin.image} coinSymbol={coin.symbol} coinVolume={coin.total_volume} coinPrice={coin.current_price} coinPriceChange={coin.price_change_percentage_24h} coinMarketCap={coin.market_cap}/>          
          );
      })}
    </>
  );
}

export default App;
