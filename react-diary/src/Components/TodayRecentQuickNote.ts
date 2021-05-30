import axios from "axios";
import { IQuickNote, ITask, IToday } from "./Interfaces";

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

// Fetch Favourites
const fetchFavourites = async () => {
  const res = await axios.get("/favourites/");
  return res.data;
};

// Fetch To Do
const fetchToDos = async () => {
  const res = await axios.get("/todo/");
  return res.data;
};

const fetchToDo = async (id: number) => {
  const res = await axios.get(`/todo/${id}`);
  return res.data;
};

const addToDo = async (
  toDo: ITask[],
  setToDo: (toDo: ITask[]) => void,
  newToDo: any
) => {
  const res = await axios.post("/todo/", newToDo);
  setToDo([...toDo, res.data]);
};

const deleteToDo = async (
  toDo: ITask[],
  setToDo: (toDo: ITask[]) => void,
  id: number
) => {
  const res = await axios.delete(`/todo/${id}`);
  setToDo(toDo.filter((task: ITask) => task.id !== id));
};

// Toggle Today (Checkboxes)
const toggleToDo = async (
  toDo: ITask[],
  setToDo: (toDo: ITask[]) => void,
  id: number
) => {
  // Fetch data
  const toDoToggle: ITask = await fetchToDo(id);
  const updatedToDo = { ...toDoToggle, isDone: !toDoToggle.isDone };

  const res = axios.put(`/todo/${id}`, updatedToDo);

  setToDo(
    toDo.map((toDo_) =>
      toDo_.id === id ? { ...toDo_, isDone: !toDo_.isDone } : toDo_
    )
  );
};

export {
  fetchTodays,
  addToday,
  toggleToday,
  fetchNotes,
  fetchQuickNotes,
  serverSetQuickNotes,
  fetchFavourites,
  fetchToDos,
  addToDo,
  deleteToDo,
  toggleToDo,
};
