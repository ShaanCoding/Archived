import { IToday } from "./Interfaces";

// Fetch Today
const fetchTodays = async () => {
  const res = await fetch("http://localhost:5000/today");
  const data = await res.json();
  return data;
};

const fetchToday = async (id: number) => {
  const res = await fetch(`http://localhost:5000/today/${id}`);
  const data = await res.json();
  return data;
};

// Update Today
const addToday = async (newToday: IToday) => {
  const res = await fetch("http://localhost:5000/today", {
    method: "POST",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify(newToday),
  });
};

// Toggle Today (Checkboxes)
const toggleToday = async (
  todayNotes: IToday[],
  setTodayNotes: (todayNotes: IToday[]) => void,
  id: number
) => {
  // Fetch data
  const todayToToggle: IToday = await fetchToday(id);
  const updatedDay = { ...todayToToggle, isDone: !todayToToggle.isDone };

  const res = await fetch(`http://localhost:5000/today/${id}`, {
    method: "PUT",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify(updatedDay),
  });

  const data: IToday = await res.json();

  setTodayNotes(
    todayNotes.map((todayNote) =>
      todayNote.id === id ? { ...todayNote, isDone: data.isDone } : todayNote
    )
  );
};

// Fetch Recent Notes
const fetchNotes = async () => {
  const res = await fetch("http://localhost:5000/recent-notes");
  const data = await res.json();
  return data;
};

// Fetch Quick Notes
const fetchQuickNotes = async () => {
  const res = await fetch("http://localhost:5000/quick-note");
  const data = await res.json();
  return data;
};

export { fetchTodays, addToday, toggleToday, fetchNotes, fetchQuickNotes };
