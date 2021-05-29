const Box: React.FC<{ isGrey: boolean }> = (props) => {
  return (
    <div className={`box ${props.isGrey && "grey"}`}>{props.children}</div>
  );
};

export default Box;
