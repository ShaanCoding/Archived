import React from "react";

const Preview: React.FC<{ text: string; userInput: string }> = (props) => {
  const text = props.text.split("");
  return (
    <div>
      {text.map((s, i) => {
        let color;
        if (i < props.userInput.length) {
          color = s === props.userInput[i] ? "#dffa0" : "#ff5454";
        }
        return (
          <span key={i} style={{ backgroundColor: color }}>
            {s}
          </span>
        );
      })}
    </div>
  );
};

export default Preview;
