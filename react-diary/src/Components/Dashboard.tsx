import Box from "./Box";

const Dashboard: React.FC = (props) => {
  return (
    <div className="dashboard">
      <h1>Dashboard</h1>
      <h2>Welcome, back!</h2>

      <Box isGrey={true}>
        <h3>TODAY</h3>
        {/* Checkboxes */}
      </Box>

      <Box isGrey={false}>
        <ul>
          <li>Journal - April</li>
          <li>Mental Health Check</li>
          <li>Workout Log</li>
        </ul>
      </Box>

      <Box isGrey={true}>
        <h3>TODAY</h3>
        <p>"We suffer more in imagination than in reality" - Seneca</p>
      </Box>
    </div>
  );
};

export default Dashboard;
