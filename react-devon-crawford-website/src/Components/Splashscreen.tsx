import { FaChevronDown } from "react-icons/fa";

const Splashscreen = () => {
  return (
    <div className="splashscreen center">
      <div>
        <h1>DEVON CRAWFORD</h1>
        <h2>
          Self-learning software and electrical engineering through research &
          development. Filming the entire process on YouTube.
        </h2>
        <p>436,000 subscribers - 56 videos</p>
      </div>
      <FaChevronDown className="splashscreen-icon" size={45} />
    </div>
  );
};

export default Splashscreen;
