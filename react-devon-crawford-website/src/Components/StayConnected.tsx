import {
  FaYoutube,
  FaTwitter,
  FaSnapchat,
  FaInstagram,
  FaGithub,
  FaDiscord,
  FaMailBulk,
} from "react-icons/fa";

const StayConnected = () => {
  return (
    <div className="stay-connected">
      <div className="center">
        <div>
          <h1>STAY CONNECTED</h1>
          <div className="stay-connected-flexbox">
            <FaYoutube size={30} />
            <FaTwitter size={30} />
            <FaSnapchat size={30} />
            <FaInstagram size={30} />
            <FaGithub size={30} />
            <FaDiscord size={30} />
            <FaMailBulk size={30} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default StayConnected;
