import React from "react";
import { render, screen } from "@testing-library/react";
import App from "./App";
import store from "./redux/store.jsx";
import { Provider } from "react-redux";

//useful link https://dev.to/siyile/quick-template-to-test-redux-tool-kit-and-react-router-with-jest-34ll
//https://redux.js.org/recipes/writing-tests

test("renders learn react link", () => {
  render(
    <Provider store={store}>
      <App />
    </Provider>
  );
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
