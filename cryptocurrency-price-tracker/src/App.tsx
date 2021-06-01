import "./App.css";
import { Box } from "@material-ui/core";
import SearchBar from "./Components/SearchBar";
import CoinList from "./Components/CoinList";
import { useState } from "react";

// https://api.coingecko.com/api/v3/coins/markets?vs_currency=AUD&order=market_cap_desc&per_page=100&page=1&sparkline=false

function App() {
  const [search, setSearch] = useState("");

  const addFilter = (filterText: string) => {
    setSearch(filterText);
  };

  return (
    <Box>
      <SearchBar addFilter={addFilter} />
      <CoinList search={search} />
    </Box>
  );
}

export default App;
