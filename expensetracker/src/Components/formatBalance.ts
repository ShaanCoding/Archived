const formatBalance = (balance: number) => {
  //We need to append $, commas as well as .00

  //Shows number of digits after decimal
  let p = balance.toFixed(2).split(".");
  return (
    "$ " +
    p[0]
      .split("")
      .reverse()
      .reduce(function (acc, num, i, orig) {
        return num === "-" ? acc : num + (i && !(i % 3) ? "," : "") + acc;
      }, "") +
    "." +
    p[1]
  );
};

export default formatBalance;
