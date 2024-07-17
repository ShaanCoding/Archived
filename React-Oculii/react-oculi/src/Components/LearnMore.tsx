const LearnMore = () => {
  return (
    <div className="box">
      <div className="learn-more">
        <h2>Connect and Learn More</h2>
        <p>
          Interested in learning more about our radar imaging products or our
          Virtual Aperture software? Let's start a conversation about how we can
          create the next generation of autonomous systems together
        </p>
        <div>
          <input type="text" placeholder="Name" />
        </div>
        <div>
          <input type="text" placeholder="Email" />
        </div>
        <div>
          <textarea placeholder="Message" />
        </div>
        <button>Send</button>
      </div>
    </div>
  );
};

export default LearnMore;
