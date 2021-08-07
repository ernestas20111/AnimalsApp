import React from 'react';
import logo from '../src/assets/svg/logo.svg';
import '../src/styles/layout/App.css';
import Counter from './components/counter.jsx';
 
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
			Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
			Learn React
        </a>
        <Counter/>
      </header>
    </div>
  );
}

export default App;