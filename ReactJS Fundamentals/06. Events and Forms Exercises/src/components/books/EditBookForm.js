import React from 'react'
import Input from '../common/Input'

const EditBookForm = (props) => (
  <form>
    <div>{props.error}</div>
    <Input
      name='title'
      placeholder='Title'
      value={props.book.title}
      onChange={props.onChange} />

    <Input
      name='image'
      type='url'
      placeholder='Image'
      value={props.book.image}
      onChange={props.onChange} />

    <Input
      name='price'
      type='number'
      placeholder='Price'
      value={props.book.price}
      onChange={props.onChange} />

    <label htmlFor='author'>Author</label>
    <select
      value={props.book.author}
      name='author'
      onChange={props.onChange}>
      {props.authors.map(author => (
        <option key={author.id} value={author.id}>{author.name}</option>
      ))}
    </select>

    <div>
      <label htmlFor='description'>Description</label>
      <textarea
        name='description'
        value={props.book.description}
        rows='10' cols='100'
        onChange={props.onChange} />
    </div>

    <input type='submit' onClick={props.onSave} />
  </form>
)

export default EditBookForm
