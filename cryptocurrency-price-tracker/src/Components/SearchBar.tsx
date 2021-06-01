import { Box, Grid, TextField } from "@material-ui/core";
import React from "react";

const SearchBar: React.FC<{ addFilter: (filterText: string) => void }> = (
  props
) => {
  const handleChange = (e: any) => {
    props.addFilter(e.target.value);
  };

  return (
    <Grid item>
      <h1>Cryptocurrency Stock Tracker</h1>
      <TextField
        id="standard-full-width"
        label="Cryptocurrency Name"
        style={{ margin: 8 }}
        placeholder="Search"
        margin="normal"
        InputLabelProps={{
          shrink: true,
        }}
        onChange={handleChange}
      />
    </Grid>
  );
};

export default SearchBar;
