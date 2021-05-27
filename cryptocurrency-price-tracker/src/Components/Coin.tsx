import React from 'react'

const Coin: React.FC<{coinImage: string, coinName: string, coinSymbol: string, coinPrice: number, coinVolume: number, coinPriceChange: number, coinMarketCap: number}> = (props) => {
    return (
        <div>
            <img src={props.coinImage} alt="Coin"/>
            <h1>{props.coinName}</h1>
            <p>{props.coinSymbol}</p>
            <div>
                <h2>${props.coinPrice}</h2>
                <p>${props.coinVolume.toLocaleString()}</p>
                {props.coinPriceChange < 0 ? (<p>{props.coinPriceChange.toFixed(2)}</p>) : (<p>{props.coinPriceChange.toFixed(2)}</p>)}
                <p>Mkt Cap: ${props.coinMarketCap.toLocaleString()}</p>
            </div>
        </div>
    )
}

export default Coin
