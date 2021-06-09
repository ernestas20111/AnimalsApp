import { configureStore } from "@reduxjs/toolkit";
import counterReducer from "./slices/counterSlice.jsx";

export default configureStore({
  reducer: {
    counter: counterReducer
  },
})