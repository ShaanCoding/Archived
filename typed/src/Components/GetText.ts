const getText = () => {
  const texts = [
    `I've been thinking lots about my life and how quick I'd wash it down the drain. Past tense, the future, nothing matters now. I act on my own and I'm to blame`,
    `I may be younger but I'll look after you. We're not in love but I'll make love to you. When you're not here I'll save some for you. I'm not him but I'll mean something to you. I'll mean something to you.`,
    `I do not see it. It is interesting that people try to find meaningful patterns in things that are essentially random. I have noticed that the images they perceive sometimes suggest what they are thinking about at that particular moment. Besides, it is clearly a bunny rabbit.`,
    `And then he calls me a jerk and says the last guy who thought he was a jerk was dead now. So I don't say nothing and he says, "What do ya think about that?" So I says, "Well, that don't sound like too good a deal for him then."`,
  ];

  return texts[Math.floor(Math.random() * texts.length)];
};

export default getText;
