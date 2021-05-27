import React from 'react'

const Coin: React.FC<{coinImage: string, coinName: string, coinSymbol: string, coinPrice: string, coinVolume: string}> = (props) => {
    return (
        <div>
            <img src={props.coinImage} alt="Coin"/>
            <h1>{props.coinName}</h1>
            <p>{props.coinSymbol}</p>
            <div>
                <h2>{props.coinPrice}</h2>
                <p>{props.coinVolume}</p>
            </div>
        </div>
    )
}

export default Coin
