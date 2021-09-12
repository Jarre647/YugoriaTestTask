import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
        Недоделал только отображение того, что запрос прошел успешно и животное добавлено/изменено. И какое либо логирование тоже, но, полагаю для тестового это не особо важно.
        И над стилями не работал, взял готовые с MaterialUi.
  </div>
);

export default connect()(Home);
