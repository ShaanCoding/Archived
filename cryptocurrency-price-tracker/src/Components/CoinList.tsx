import { Grid, Table } from "@material-ui/core";
import axios from "axios";
import React, { useEffect, useState } from "react";
import Coin from "./Coin";

const CoinList: React.FC<{ search: string }> = (props) => {
  const [coins, setCoins] = useState([]);

  useEffect(() => {
    axios
      .get(
        "https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false"
      )
      .then((res) => {
        setCoins(res.data);
        // console.log(res.data);
      })
      .catch((error) => {
        alert(error);
      });
  }, []);

  const filteredCoins = coins.filter((coin: any) =>
    coin.name.toLowerCase().includes(props.search.toLowerCase())
  );

  return (
    <Grid item>
      <Grid container justify="center" spacing={1} className="coinElement">
        {/* Map all coins here */}

        {filteredCoins.map((coin: any) => {
          return (
            <Coin
              key={coin.id}
              coinName={coin.name}
              coinImage={coin.image}
              coinSymbol={coin.symbol}
              coinVolume={coin.total_volume}
              coinPrice={coin.current_price}
              coinPriceChange={coin.price_change_percentage_24h}
              coinMarketCap={coin.market_cap}
            />
          );
        })}
      </Grid>
    </Grid>
  );
};

export default CoinList;
