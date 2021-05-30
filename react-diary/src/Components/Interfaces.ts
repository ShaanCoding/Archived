export interface IToday {
  id: number;
  taskName: string;
  isDone: boolean;
}

export interface IRecentNotes {
  id: number;
  noteName: string;
  noteURL: string;
}

export interface IQuickNote {
  name: string;
}

export interface IFavourites {
  id: number;
  favouriteName: string;
  favouriteURL: string;
}

export interface ITask {
  id: number;
  taskName: string;
  isDone: boolean;
}
