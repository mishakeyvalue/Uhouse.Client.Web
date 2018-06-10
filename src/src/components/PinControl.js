import React from 'react'

const PinControl = ({pinId, isEnabled, onClickOn, onClickOff}) => (
    <div>
        <h3>Pin #{pinId}</h3>
        <p>{isEnabled ? 'true' : 'false'}</p>
        <button onClick={onClickOn}>Turn on</button>
        <button onClick={onClickOff}>Turn off</button>
    </div>
)

export default PinControl;