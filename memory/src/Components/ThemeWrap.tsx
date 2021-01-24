import { createMuiTheme, CssBaseline, ThemeProvider } from "@material-ui/core";
import { purple, green, blue } from "@material-ui/core/colors";

const theme = createMuiTheme({
  palette: {
    type: "dark",
    primary: {
      main: blue[500],
    },
    secondary: {
      main: green[500],
    },
  },
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
