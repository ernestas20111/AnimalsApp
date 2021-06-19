import { combineReducers } from "redux";
import counterReducer from "./slices/counterSlice.jsx";

const rootReducer = combineReducers({
  counter: counterReducer
});

export default rootReducer;