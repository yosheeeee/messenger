import "./style.scss"
import React, {MouseEventHandler} from "react";

export const AuthWindow = () => {
	const closeWindow  : MouseEventHandler<HTMLButtonElement> = (event )  => {
		let layout = document.getElementsByClassName("modallayout")[0]
		layout.classList.add("closed")
		let window = document.getElementsByClassName("modalwindow")[0]
		window.classList.add("closed")

	}
	return (
		<>
			<div className="modallayout"></div>
			<div className="modalwindow">
				<button onClick={closeWindow}>Close</button>
			</div>
		</>
	)
}