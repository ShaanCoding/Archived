import React from "react";

const Speed: React.FC<{ symbols: number; sec: number }> = (props) => {
  if (props.symbols !== 0 && props.sec !== 0) {
    const wpm = props.symbols / 5 / (props.sec / 60);
    return (
      <div>
        <h2>{Math.round(wpm)} WPM</h2>
      </div>
    );
  }

  return null;
};

export default Speed;
