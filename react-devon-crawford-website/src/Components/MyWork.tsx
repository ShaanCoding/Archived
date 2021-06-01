const MyWork = () => {
  return (
    <div className="my-work">
      <h1>MY WORK</h1>
      <p>
        I was never the best at school or academics, I’m just a super curious
        guy. My channel exists to share these ideas and theories that interest
        me. I spend a lot of time building software and electronics, but there’s
        also a lot more to it. I’ve been working on a video format to document
        the logic, reasoning, and problems encountered during the process of
        learning engineering. A combination of innovation and storytelling.
      </p>

      <div className="my-work-flexbox">
        <div>
          <h2>Software Development</h2>
          <ul>
            <li>Java/C# Automation. CPU bound business logic</li>
            <li>Low level/embedded IoT programming</li>
            <li>Cloud computing, microservices, APIs, full stack web apps</li>
          </ul>
        </div>

        <div>
          <h2>Electronics</h2>
          <ul>
            <li>LED Music visualizer</li>
            <li>Robotics, batteries, embedded systems</li>
            <li>
              Trying to not blow myself up by teaching myself EE is quite
              exciting
            </li>
          </ul>
        </div>

        <div>
          <h2>Video Production</h2>
          <ul>
            <li>
              Developer Vlog: Document the learning process of engineering
            </li>
            <li>
              Weekly videos on YouTube. Building a community of technology
              enthusiasts.
            </li>
            <li>High quality visuals and meaningful stories</li>
          </ul>
        </div>

        <div>
          <h2>Community</h2>
          <ul>
            <li>Open source projects on Github</li>
            <li>Discord</li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default MyWork;
