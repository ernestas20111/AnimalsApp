import { compose, createStore } from "@reduxjs/toolkit";
import { applyMiddleware} from "redux";
import rootReducer from "../redux/rootReducer.jsx";
import reduxImutableStateInvariant from "redux-immutable-state-invariant";
import thunk from "redux-thunk";

function configureStore(){
  const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
  return createStore(
    rootReducer,
    composeEnhancers(applyMiddleware(thunk, reduxImutableStateInvariant()))
  );
}

const store = configureStore();

export default store;