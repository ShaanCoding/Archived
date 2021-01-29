import { createMuiTheme, CssBaseline, ThemeProvider } from "@material-ui/core";

const theme = createMuiTheme({
  palette: {
    type: "dark",
    primary: {
      main: "#ffffff",
    },
    secondary: {
      main: "#ffdc15",
    },
  },
  spacing: [0, 8, 16, 24, 32],
});

const ThemeWrap: React.FC = (props) => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      {props.children}
    </ThemeProvider>
  );
};

export default ThemeWrap;
