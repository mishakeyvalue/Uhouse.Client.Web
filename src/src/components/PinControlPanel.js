import React from 'react'

import PinControl from './PinControl'

const PinControlPanel = ({pins, turnOn, turnOff}) => {

    return (
        <div>
            <h2> Pin control panel </h2>

            {pins.map(pin => 
                <PinControl 
                    key={pin.id} 
                    pinNumber={pin.id} 
                    isEnabled={pin.isEnabled} 
                    onClickOn={() => turnOn(pin.id)} 
                    onClickOff={() => turnOff(pin.id)}
                /> )}
        </div>
    )

}

export default PinControlPanel;