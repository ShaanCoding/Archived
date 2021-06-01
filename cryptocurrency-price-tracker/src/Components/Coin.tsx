import { Grid } from "@material-ui/core";
import React from "react";

const Coin: React.FC<{
  coinImage: string;
  coinName: string;
  coinSymbol: string;
  coinPrice: number;
  coinVolume: number;
  coinPriceChange: number;
  coinMarketCap: number;
}> = (props) => {
  return (
    <Grid container justify="center" alignItems="center" spacing={3}>
      <Grid item>
        <img src={props.coinImage} alt="Coin" />
      </Grid>
      <Grid item>
        <h1>{props.coinName}</h1>
        <p>Symbol: {props.coinSymbol.toUpperCase()}</p>
      </Grid>
      <Grid item>
        <h2>Coin Price: ${props.coinPrice}</h2>
        <p>Coin Volume: ${props.coinVolume.toLocaleString()}</p>
        {props.coinPriceChange < 0 ? (
          <p>Coin Price Change: {props.coinPriceChange.toFixed(2)}</p>
        ) : (
          <p>Coin Price Change: {props.coinPriceChange.toFixed(2)}</p>
        )}
        <p>Market Cap: ${props.coinMarketCap.toLocaleString()}</p>
      </Grid>
    </Grid>
  );
};

export default Coin;
