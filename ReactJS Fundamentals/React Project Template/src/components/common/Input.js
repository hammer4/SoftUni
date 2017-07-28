import React from 'react'

const Input = (props) => {
  let type = props.type || 'text'

  return (
    <div>
      <label htmlFor={props.name}>{props.placeholder}</label>
      <input
        type={type}
        name={props.name}
        placeholder={props.placeholder}
        value={props.value}
        onChange={props.onChange}
        required={props.required}
        minLength={props.minLength}
        min={props.min} />
    </div>
  )
}

export default Input
