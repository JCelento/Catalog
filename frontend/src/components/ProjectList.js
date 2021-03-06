import ProjectPreview from './ProjectPreview';
import ListPagination from './ListPagination';
import React from 'react';

const ProjectList = props => {
  if (props.projectsCount === 0) {
    return (
      <div className="article-preview">
        Não encontramos nenhum projeto para mostrar :(
      </div>
    );
  }

  
  if (!props.projects) {
    return (
      <div className="article-preview">Carregando...</div>
    );
  }

  if (props.projects.length === 0) {
    return (
      <div className="article-preview">
        Não encontramos nenhum projeto para mostrar :(
      </div>
    );
  }

  return (
    <div>
      {
        props.projects.map(project => {
          return (
            <ProjectPreview project={project} key={project.slug} />
          );
        })
      }

      <ListPagination
        pager={props.pager}
        projectsCount={props.projectsCount}
        currentPage={props.currentPage} />
    </div>
  );
};

export default ProjectList;
