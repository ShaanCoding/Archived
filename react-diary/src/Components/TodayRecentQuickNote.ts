import axios from "axios";
import { IQuickNote, IToday } from "./Interfaces";

// Fetch Today
const fetchTodays = async () => {
  const res = await axios.get("/today");
  return res.data;
};

const fetchToday = async (id: number) => {
  const res = await axios.get(`/today/${id}`);
  return res.data;
};

// Update Today
const addToday = async (newToday: IToday) => {
  axios.post("/today", newToday);
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

  const res = axios.put(`/today/${id}`, updatedDay);

  setTodayNotes(
    todayNotes.map((todayNote) =>
      todayNote.id === id
        ? { ...todayNote, isDone: !todayNote.isDone }
        : todayNote
    )
  );
};

// Fetch Recent Notes
const fetchNotes = async () => {
  const res = await axios.get("/recent-notes/");
  return res.data;
};

// Fetch Quick Notes
const fetchQuickNotes = async () => {
  const res = await axios.get("/quick-note/");
  return res.data;
};

// Set Quick Notes
const serverSetQuickNotes = async (newNotes: IQuickNote) => {
  await axios.put("/quick-note/", newNotes);
};

export {
  fetchTodays,
  addToday,
  toggleToday,
  fetchNotes,
  fetchQuickNotes,
  serverSetQuickNotes,
};
