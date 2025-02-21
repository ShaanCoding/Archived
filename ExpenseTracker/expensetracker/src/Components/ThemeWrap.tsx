import { createMuiTheme, CssBaseline, ThemeProvider } from "@material-ui/core";
import { purple, green, blue } from "@material-ui/core/colors";

const theme = createMuiTheme({
  palette: {
    type: "dark",
    secondary: {
      main: "#ffffff",
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
