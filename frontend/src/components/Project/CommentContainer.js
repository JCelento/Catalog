import CommentInput from './CommentInput';
import CommentList from './CommentList';
import { Link } from 'react-router-dom';
import React from 'react';

const CommentContainer = props => {
  if (props.currentUser) {
    return (
      <div className="col-xs-12 col-md-8 offset-md-2">
        <div>
          <list-errors errors={props.errors}></list-errors>
          <CommentInput slug={props.slug} currentUser={props.currentUser} />
        </div>

        <CommentList
          comments={props.comments}
          slug={props.slug}
          currentUser={props.currentUser} />
      </div>
    );
  } else {
    return (
      <div className="col-xs-12 col-md-8 offset-md-2">
       <CommentList
          comments={props.comments}
          slug={props.slug}
          currentUser={props.currentUser} />
      <div className="col-xs-12 offset-md-5">
        <p>
          <Link to="/login">Faça Login</Link>
          &nbsp;ou&nbsp;
          <Link to="/register">Cadastre-se</Link>
        </p>
        </div>
        </div>
    );
  }
};

export default CommentContainer;
