import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import { Routes, RoutesComponent } from "./RoutesPath/routesComponent";
import { HubConnectionBuilder } from "@microsoft/signalr";

function App() {
  return <RoutesComponent />;

  // return (
  //   <>
  //     <Routes/>
  //     {/* <div>
  //       <a href="https://vitejs.dev" target="_blank">
  //         <img src={viteLogo} className="logo" alt="Vite logo" />
  //       </a>
  //       <a href="https://react.dev" target="_blank">
  //         <img src={reactLogo} className="logo react" alt="React logo" />
  //       </a>
  //     </div>
  //     <h1>SignalRChat</h1>
  //     <h3></h3>
  //     <div className="card">

  //     </div>
  //     <p className="read-the-docs">
  //       Click on the Vite and React logos to learn more
  //     </p> */}
  //   </>
  // )
}

export default App;
