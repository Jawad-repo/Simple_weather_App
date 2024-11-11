import React, { useState, useEffect } from "react";
import logo from './logo.svg';
import axios from "axios";
import './App.css';

const BASE_URL = 'https://localhost:7013';

function App() {

  const [weather, setWeather] = useState({
    loading: true,
    data: [], // Assuming the API returns an array of weather data
    error: false,
  });

  const fetchWeatherdata = async () => {
    const url = `${BASE_URL}/weatherforecast/`;
    try {
      const res = await axios.get(url);
      setWeather({ data: res.data, loading: false, error: false });
    } catch (error) {
      setWeather({ ...weather, data: [], error: true });
    }
  };

  useEffect(() => {
    fetchWeatherdata();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        {weather.loading ? (
          <p>Loading...</p>
        ) : weather.error ? (
          <p>Error loading data</p>
        ) : (
          <p>Summary: {weather.data[0]?.summary || "No summary available"}</p>
        )}
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;