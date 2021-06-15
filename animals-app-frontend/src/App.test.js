import React from "react";
import { render, screen } from "@testing-library/react";
import App from "./App";
import store from "./redux/store.jsx";
import { Provider } from "react-redux";

//useful link https://dev.to/siyile/quick-template-to-test-redux-tool-kit-and-react-router-with-jest-34ll

test("renders learn react link", () => {
  render(
    <Provider store={store}>
      <App />
    </Provider>
  );
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toContainElement(document.getElementsByClassName("App-link")[0]);
});
